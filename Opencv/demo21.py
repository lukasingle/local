import cv2 as cv2
import matplotlib.pyplot as plt
import numpy as np

img = cv2.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
#灰度图
img = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

mask = np.ones(img.shape, np.uint8)
mask = mask*200
img = cv2.addWeighted(img, 0.3 ,mask,0.3, 0)
#均衡化直方图
img2 = cv2.equalizeHist(img)

#在当前窗口加子窗口
plt.subplot(1,2,1)
plt.hist(img2.ravel(),256)
plt.subplot(122)
plt.hist(img.ravel(),256)


plt.show()









