import time
import redis
import json
r = redis.Redis()

#auto publish
autoNum = 0
def auto_pub():
    global autoNum
    autoNum += 1
    return str(autoNum)

seq_num = 0
def SequenceNumber():
    global seq_num
    seq_num += 1
    return str(seq_num)

pubs = ['ch_01', 'ch_02', 'ch_03']
# Publish messages to a channel
while True:
    # message = input("Enter a message: ")
    time.sleep(.8)
    
    for pub in pubs:
        message = auto_pub()
        message_payload = {
            'time_stamp' : time.time(),
            'data_type' : '222',
            'data' : message,
            'seq' : SequenceNumber(),
        }
        print(f'send message to {pub}')
        new_message_payload = json.dumps(message_payload)
        r.publish(pub, new_message_payload)
