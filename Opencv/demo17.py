import cv2 as cv2
import matplotlib.pyplot as plt
import numpy as np

img = cv2.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
#灰度图
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
#二值图像
ret, thresh1 = cv2.threshold(gray,40,255,cv2.THRESH_BINARY)
#向下采样
imgG = cv2.pyrDown(thresh1)
#拉普拉斯金字塔
imgL = thresh1 - cv2.pyrUp(imgG)
#
img = imgL + cv2.pyrUp(imgG)

#向下采样
titles = ['imgG','imgL','img']
images = [imgG,imgL,img]

for i in [0,1,2]:
    plt.subplot(1,3,i+1)
    plt.imshow(images[i],'gray')
    plt.title(titles[i])
plt.show()





