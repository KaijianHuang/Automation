import redis
import threading
import time
import json
# Connect to Redis
r = redis.Redis()

# Subscribe to a channel
p = r.pubsub()

p.subscribe('kz_pub')

class Topic:
    def __init__(self,_name = None, _type = None, _datatype = int, sub_channel = []):
        self.name = _name
        self.type = _type
        self.datatype = _datatype
        # self.id = SequenceNumber()
        self.sub_channel = sub_channel

def run_pubsub(topics:list):
    #new topics created, and try to listen to subscribers
    print(f'Start listensing')
    r = redis.Redis()
    p = r.pubsub()
    while True:
        for topic in topics:
            p.subscribe(topic.sub_channel)
            for message in p.listen():
                if message['type'] == 'message':
                    channel = message['channel'].decode('utf-8')
                    data_json = message['data'].decode('utf-8')
                    data = json.loads(data_json)
                    print(f'From channel {channel} get json response {data}, the data is {data["data"]} at time {data["time_stamp"]}')
                    # print(time)
                    topic.data = data["data"]
        # for topic in topics:
        #     print('-------------print topic data------------------')
        #     print(f'topic: {topic.name}, data:{topic.data}')
        #     print('-------------end print-------------------------')

def scheduler():
    print(f'here is scheduler, sleep .5')
    while True:
        print(f'sleeppppp....')
        time.sleep(.5)

if __name__ == "__main__":
    # Listen for messages
     
    topics = [Topic("topic01", None, None, ["ch_01", "ch_02"]),Topic("topic02", None, None, ["ch_03", "ch_02"])]
    thread_pool = []
    thread_subpub = threading.Thread(target=run_pubsub, args= [topics])
    thread_scheduler = threading.Thread(target=scheduler)
    thread_pool.append(thread_subpub)
    thread_pool.append(thread_scheduler)
    for thread in thread_pool:
        thread.start()
    for thread in thread_pool:
        thread.join()
    
    
    
    # for message in p.listen():
    #     if message['type'] == 'message':
    #         channel = message['channel'].decode('utf-8')
    #         data = message['data'].decode('utf-8')
    #         print(f"Received message from channel '{channel}': {data}")
    
