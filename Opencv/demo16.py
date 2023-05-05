import cv2 as cv2
import matplotlib.pyplot as plt
import numpy as np

img = cv2.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
#灰度图
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
#二值图像
ret, thresh1 = cv2.threshold(gray,40,255,cv2.THRESH_BINARY)
img1 = cv2.pyrDown(thresh1)
img2 = cv2.pyrDown(img1)
img3 = cv2.pyrDown(img2)

#向下采样
titles = ['img1','img2','img3']
images = [img1,img2,img3]

for i in [0,1,2]:
    plt.subplot(1,3,i+1)
    plt.imshow(images[i],'gray')
    plt.title(titles[i])
plt.show()





