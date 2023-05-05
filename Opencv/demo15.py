import cv2 as cv2
import matplotlib.pyplot as plt
import numpy as np

img = cv2.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

ret, thresh1 = cv2.threshold(gray,40,255,cv2.THRESH_BINARY)
cv2.imshow("thresh1",thresh1)

img2 = cv2.Canny(thresh1,127,200)
cv2.imshow("img2",img2)

cv2.waitKey(0)
cv2.destroyAllWindows()



