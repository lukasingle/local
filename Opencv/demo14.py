import cv2 as cv2
import matplotlib.pyplot as plt
import numpy as np

img = cv2.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

ret, thresh1 = cv2.threshold(gray,40,255,cv2.THRESH_BINARY)


median = cv2.medianBlur(thresh1,13)

plt.imshow(median,'gray')
plt.axis('on')
plt.title("hehe")

plt.show()


