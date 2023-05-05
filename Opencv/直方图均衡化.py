import cv2 as cv2
import numpy as np
import matplotlib.pyplot as plt
#读取图片
img = cv2.imread("104.jpg")
#设置成灰度图
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

plt.hist(gray.ravel(),256)
plt.show()

equ = cv2.equalizeHist(gray)
plt.hist(equ.ravel(),256)
plt.show()

clahe = cv2.createCLAHE(clipLimit=9.0)

res_clahe = clahe.apply(gray)
plt.hist(res_clahe.ravel(),256)
plt.show()

cv2.imshow("gray",gray)
cv2.imshow("equ",equ)
cv2.imshow("clahe",res_clahe)
cv2.waitKey(0)
cv2.destroyAllWindows()



# ax = plt.hist(gray.ravel(), bins=256)

# histequ = cv2.equalizeHist(gray)


# plt.title("grayimage")
# plt.show()
# plt.imshow(cv2.cvtColor(histequ, cv2.COLOR_BGR2RGB))
# plt.show()
