import cv2 as cv2
import matplotlib.pyplot as plt
import numpy as np

img = cv2.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
#灰度图
img = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

#matplotlib绘制直方图
plt.hist(img.ravel(),256)
plt.show()

cv2.imshow("img",img)
cv2.waitKey(0)
cv2.destroyAllWindows()







