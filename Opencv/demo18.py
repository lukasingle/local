import cv2 as cv2
import matplotlib.pyplot as plt
import numpy as np

img = cv2.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
#灰度图
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
#二值图像
ret, thresh1 = cv2.threshold(gray,40,255,cv2.THRESH_BINARY)
#查找轮廓
image, contours, hierarchy = cv2.findContours(thresh1,cv2.RETR_EXTERNAL,cv2.CHAIN_APPROX_SIMPLE)
#绘制轮廓
img = cv2.drawContours(img,contours,-1,(0,0,255),2)
print(len(contours))
print("")
cv2.imshow("hehe",img)
cv2.waitKey(0)
cv2.destroyAllWindows()







