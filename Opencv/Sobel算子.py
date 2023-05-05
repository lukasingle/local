import cv2 as cv2
import numpy as np
#读取图片
img = cv2.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
#设置成灰度图
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
#二值化
t1, dst1 = cv2.threshold(gray, 40, 255, cv2.THRESH_BINARY)
#sobel边缘检测x
sobelx = cv2.Sobel(dst1, cv2.CV_64F,1,0,ksize=3)
#sobel边缘检测y
sobely = cv2.Sobel(dst1, cv2.CV_64F,0,1,ksize=3)
cv2.imshow("dst1",dst1)
cv2.imshow("sobelx",sobelx)
cv2.imshow("sobely",sobely)
cv2.waitKey(0)
cv2.destroyAllWindows()