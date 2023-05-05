import cv2 as cv2
import numpy as np
#读取图片
img = cv2.imread("104.jpg")
#设置成灰度图
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
#二值化
t1, dst1 = cv2.threshold(gray, 40, 255, cv2.THRESH_BINARY)
#中值滤波
result1 = cv2.medianBlur(dst1,5)
#高斯滤波
result2 = cv2.GaussianBlur(dst1,(0,0),8)

cv2.imshow("original",dst1)
cv2.imshow("result1",result1)
cv2.imshow("result2",result2)
cv2.waitKey(0)
cv2.destroyAllWindows()