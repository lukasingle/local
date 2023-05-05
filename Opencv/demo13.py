import cv2 as cv2
import matplotlib.pyplot as plt
import numpy as np

img = cv2.imread("C:\\Users\\25582\\Desktop\\images\\54.jpg")
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

ret, thresh1 = cv2.threshold(gray,40,255,cv2.THRESH_BINARY)
ret, thresh2 = cv2.threshold(gray,40,255,cv2.THRESH_BINARY_INV)
ret, thresh3 = cv2.threshold(gray,40,255,cv2.THRESH_TRUNC)
ret, thresh4 = cv2.threshold(gray,40,255,cv2.THRESH_TOZERO)
ret, thresh5 = cv2.threshold(gray,40,255,cv2.THRESH_TOZERO_INV)

titles = ['orig','BINARY','BINARY_INV','TRUNC','TOZERO','TOZERO_INV']
images = [img, thresh1,thresh2,thresh3,thresh4,thresh5]

for i in [0,1,2,3,4,5]:
    plt.subplot(2,3,i+1)
    plt.imshow(images[i], 'gray')
    plt.title(titles[i])
plt.show()



cv2.waitKey(0)
cv2.destroyAllWindows()