import cv2 as cv2
import numpy as np

img = cv2.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
t1, dst1 = cv2.threshold(gray, 40, 255, cv2.THRESH_BINARY)
ret, thresh = cv2.threshold(dst1,127,255, cv2.THRESH_BINARY)
cv2.imshow("thresh",thresh)

binary, contours, hierarchy = cv2.findContours(thresh, cv2.RETR_TREE, cv2.CHAIN_APPROX_NONE)

draw_img = img.copy()
res = cv2.drawContours(img, contours, -1, (0,0,255),2)
cv2.imshow("res",res)

cnt = contours[33]
print(cv2.contourArea(cnt))

cv2.waitKey(0)
cv2.destroyAllWindows()