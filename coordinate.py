import cv2
from cvzone.HandTrackingModule import HandDetector
import socket


cap = cv2.VideoCapture(0)
camWidth = cap.get(cv2.CAP_PROP_FRAME_WIDTH)
camHeight = cap.get(cv2.CAP_PROP_FRAME_HEIGHT)

detector = HandDetector(maxHands=1, detectionCon=0.8)

#Communication
sock = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1",5052)


while True:
    #get the frame from the webcam
    success, image = cap.read()
    #hands
    hands,image = detector.findHands(image)

    #holding data for two points in each frame
    data = []

    if hands:
        hand = hands[0] #first hand detected
        pt5 = hand['lmList'][5]
        pt17 = hand['lmList'][17]
        data.extend([pt5[0],camHeight-pt5[1],pt5[2]])
        data.extend([pt17[0],camHeight-pt17[1],pt17[2]])
    
    if data != []:
        print(data)

    sock.sendto(str.encode(str(data)),serverAddressPort)

    cv2.imshow("Image",cv2.flip(image,1))
    cv2.waitKey(1)