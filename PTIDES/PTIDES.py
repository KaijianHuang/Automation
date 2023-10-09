import redis
import heapq
import threading
from collections import defaultdict
import time
import json
from queue import PriorityQueue

#example for event_queue, {"sub01":(min-heap)[[1687679337.8990679, seq, data], ]}
event_queue = {}
def action_a(val):
    print(f'in action a, do val muliply 2: {val} * 2 = {val*2}')
    val *= 2
    return val

def action_b(val):
    print(f'in action b, do val plus 1: {val} + 1 = {val+1}')
    val += 1
    return val

def action_c(val1, val2):
    val = val1 + val2
    print(f'in action c, do val1 plus val2: {val1} + {val2} = {val}')
    return val

seq_num = 0
def SequenceNumber():
    global seq_num
    seq_num += 1
    return seq_num 

class Functions:
    def __init__(self, topic = [], func = None, pub = []):
        self.topic = topic
        self.function = func
        self.pub_trigger = pub

    def add_topic(self, topic):
        self.topic.append(topic)
    
    def set_function(self, function):
        self.function = function
    
    def add_pub(self, pub):
        self.pub_trigger.append(pub)

class Graph:
    def __init__(self, v = [], e = {}, w = {}):
        self.V = v
        self.E = e
        self.W = w
        self.L = 1
        for vertex in self.V:
            self.E[vertex] = []

    def add_V(self, v):
        self.V.append(v)
    
    def add_E(self, source, destination, weight):
        self.E[source].append(destination)
        self.W[(source,destination)] = weight
        destination.sub_channel = source.name
    
    def set_L(self):
        print('set L')

    def get_min_path(self, p, v):
        print(f"get min path from {p} to {v}")

    def get_dependency_cut(self, p):
        print(f"get dependency cut of {p}")
    
    #find shortest path and return the minmum delay
    def findShortestPath(self,source, destination):
        distances = {vertex: float('inf') for vertex in graph.V}
        distances[source] = 0

        pq = PriorityQueue()
        pq.put((0, source))

        previous = {}

        while not pq.empty():
            current_distance, current_vertex = pq.get()

            if current_vertex == destination:
                break

            if current_distance > distances[current_vertex]:
                continue

            for neighbor in graph.E[current_vertex]:
                weight = graph.W.get((current_vertex, neighbor), float('inf'))
                distance = current_distance + weight

                if distance < distances[neighbor]:
                    distances[neighbor] = distance
                    pq.put((distance, neighbor))
                    previous[neighbor] = current_vertex

        if distances[destination] == float('inf'):
            return None

        path = []
        current = destination
        while current is not None:
            path.append(current)
            current = previous.get(current)

        path.reverse()
        return distances[destination], path

    
class Topic:
    def __init__(self,_name = None, _type = None, _datatype = int, sub_channel = []):
        self.name = _name
        self.type = _type
        self.datatype = _datatype
        self.id = SequenceNumber()
        self.sub_channel = sub_channel
        

def init():
    # define topics
    A_sub = Topic("A_sub", "sub", int)
    A_pub = Topic("A_pub", "pub", int)
    B_sub = Topic("B_sub", "sub", int)
    B_pub = Topic("B_pub", "pub", int)
    C_sub = Topic("C_sub", "sub", int)
    C_pub = Topic("C_pub", "pub", int)
    D_sub = Topic("D_sub", "sub", int)
    D_pub = Topic("D_pub", "pub", int)  
    graph = Graph([A_sub,A_pub,B_sub,B_pub,C_sub,C_pub,D_sub,D_pub])
    graph.add_E(A_sub, A_pub, 0)
    graph.add_E(B_sub, B_pub, 0)
    graph.add_E(C_sub, C_pub, 0)
    graph.add_E(D_sub, D_pub, 0)
    graph.add_E(A_pub, C_sub, 10)
    graph.add_E(B_pub, C_sub, 2)
    graph.add_E(C_pub, D_sub, 3)
    graph.add_E(A_pub, B_sub, 0)
    """
    Graph(E):

    A_sub->A_pub -|
                   ->C_sub->C_pub->D_sub->D_pub 
    B_sub->B_pub -|
    
    """
    pubsub = [A_sub,A_pub,B_sub,B_pub,C_sub,C_pub,D_sub,D_pub]
    functions = []
    functions.append(Functions(["A_sub"],action_a, ["A_pub"]))
    functions.append(Functions(["B_sub"],action_b, ["B_pub"]))
    functions.append(Functions(["C_sub"],action_c, ["C_pub"]))
    return (graph, pubsub, functions)

def run_pubsub(pubsub):
    global event_queue
    print("run pub_sub")
    while True:
        r = redis.Redis()
        p = r.pubsub()
        for channel in pubsub:
            #traverse pubsub to listen on change from publisher
            p.subscribe(topic.sub_channel)
            for message in p.listen():
                if message['type'] == 'message':
                    from_channel = message['channel'].decode('utf-8')
                    data_json = message['data'].decode('utf-8')
                    data = json.loads(data_json)
                    print(f'From channel {from_channel} get json response {data}, the data is {data["data"]} at time {data["time_stamp"]}')
                    #push the data into global event_queue, since it is hashtable,
                    if channel.name in event_queue:
                        heapq.heappush(event_queue[channel.name], [data["time_stamp"], data["seq"], data["data"]])
                    else:
                        event_queue[channel.name] = []
                    heapq.heappop(event_queue[from_channel.name])
                    #update the value in topic(class)
                    topic.data = data["data"]


        for topic in pubsub:
            print('-------------print topic data------------------')
            print(f'topic: {topic.name}, data:{topic.data}')
            print('-------------end print-------------------------')

#get the Gi and Ci from graph according to the input port i
#return a list of G(i) and C(i) and segma(p, i) and segm a0(pk, pk+1) of all port
#
def graph_init(graph) -> list:
    print("get the G(i) and C(i);")
    for edges in graph.E:
        (source, destination) = edges
        #get the weight of this edge of source and dest
        weight = graph.W[edges]


# def get_shortest_path(graph, source, dest):


def scheduler():
    global event_queue
    print("scheduler")
    while True:
        cur_event = {}
        for event in event_queue:
            min_event = event_queue[event].heappop()
            cur_event[event] = min_event
        cur_event.sort()
'''        
        step1: get the current event with min time_stamp 
        step2: check if it is safe to run:
                1. get current real time and check if real time has exceeded: tao + max(D(p)-segma(p,i))
                    if yes:
                        pop current event since it is post-time event
                    else:
                        check if it is safe to porcess
                2. use current port get C(i) and G(i), continue to check PTIDES model safety

'''     
        


        
def isSafe():
    print("check if it is safe to process")


if __name__ == "__main__":
    (graph, pubsub, functions) = init()
    dis, path = graph.findShortestPath(pubsub[0],pubsub[-1])
    print(f'dis is {dis}, and path is {path}')

    # #create threads to do scheduler
    # thread_pools = []
    # thread_pubsub = threading.Thread(target = run_pubsub, args = [])
    # thread_scheduler = threading.Thread(target = scheduler)
    # thread_pools.append(thread_pubsub)
    # thread_pools.append(thread_scheduler)
    # for thread in thread_pools:
    #     thread.start()
    # for thread in thread_pools:
    #     thread.join()
    

    