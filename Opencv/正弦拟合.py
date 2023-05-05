# -*- coding: utf-8 -*-

# 霍夫正弦曲线检测
import numpy as np
from numpy import random
from matplotlib import pyplot as plt
from mpl_toolkits.mplot3d.axes3d import Axes3D, get_test_data
from matplotlib import cm
import cv2
#设置图像的宽为200
row = 200
#设置图像的长为200
col = 200
#创建长宽分别为200和200的白色图像
pic = np.ones((row, col)) * 255
#设置正弦曲线中的参数A1
A1 = 40
#设置
phil = 180
#设置基线y0 = 100
baseline1 = 100
h = 1
#生成一个正弦函数图像
for i in range(200):
    y1 = A1 * (np.sin(i * 2 * np.pi / 200 - np.pi * 60 / 180)) + baseline1  # 创建这么一个正弦曲线
    pic[int(y1), i] = 0


#    for j in range(int(y1)-h),(int(y1)+h):
#        pic[j,i]=0

#------------------------------------------------------------------------------------------------------------------------
#显示生成的正弦函数
# cv2.imshow("pic",pic)


# 定义添加椒盐噪声的函数
def SaltAndPepper(src, percetage):
    """椒盐噪声,输入图像和比例"""
    SP_NoiseImg = src
    SP_NoiseNum = int(percetage * src.shape[0] * src.shape[1])
    for i in range(SP_NoiseNum):
        randX = random.random_integers(0, src.shape[0] - 1)
        randY = random.random_integers(0, src.shape[1] - 1)
        if random.random_integers(0, 1) == 0:
            SP_NoiseImg[randX, randY] = 0
        else:
            SP_NoiseImg[randX, randY] = 255
    return SP_NoiseImg


C:\Users\25582\PycharmProjects\untitled2\Opencv



SP_NoiseImg = SaltAndPepper(pic, 0.01)

#显示添加了椒盐噪声的正弦曲线
cv2.imshow("SP_NoiseImg",SP_NoiseImg)

def houghSinWave(img):
    """y = A*sin(w*x+φ)+y0"""
    row, col = img.shape
    # 参数设定
    iMaxAmp = row  # 幅度A
    iMaxAngleNumber = 360  # 相位,360度，不划分步长的话就是1度1度的算
    iMaxY0 = int(row)  # 正弦曲线基线,假定基线是知道的，为100
    # 累加器
    accumulator = np.zeros((iMaxAmp, iMaxAngleNumber), np.int32)

    # 创建字典,用于存储坐标
    accuDict = {}
    for k1 in range(iMaxAmp):
        for k2 in range(iMaxAngleNumber):
            accuDict[(k1, k2)] = []

    # 投票计数
    for i in range(row):
        for j in range(col):
            if img[i, j] == 0:  # 对黑色点做霍夫变换
                for m in range(iMaxAngleNumber):  # 对每一个β值计算其A值（幅度）
                    if np.sin(np.pi * 2 * j / 200 - m / (2 * np.pi)) != 0:  # 分子不能为0
                        A = (i - baseline1) / (np.sin(np.pi * 2 * j / 200 - m * np.pi / 180))
                        if A < iMaxAmp and A > 0:  # 幅值A不会有太大，去掉异常值情况
                            n = int(A)
                            accumulator[n, m] += 1  # 投票+1

                            # 记录该点
                            accuDict[(n, m)].append((i, j))
    return accumulator, accuDict


accumulator, accuDict = houghSinWave(SP_NoiseImg)
rows,cols =accumulator.shape
fig = plt.figure(figsize=plt.figaspect(0.5))

#计数器的二维显示
#ax = fig.add_subplot(111, projection='3d')
ax = fig.add_subplot(1, 2, 1, projection='3d')
X,Y = np.mgrid[0:rows:1, 0:cols:1]
surf = ax.plot_wireframe(X,Y, accumulator, cstride=1,rstride=1)
ax.set_xlabel(u'&\\A&')
ax.set_ylabel(u'&\\β&')
#ax.set_xlabel(u'&\\accumulator&')
ax.set_zlim3d(0,np.max(accumulator))
plt.show()

#计数器灰度级显示
# grayAccu = accumulator/float(np.max(accumulator))
# grayAccu = 255*grayAccu
# grayAccu = grayAccu.astype(np.uint8)
# cv2.imshow('grayAccu',grayAccu)


voteThresh=50

count = [0, (0, 0)]  # 分别存储的是最大投票数，A的值和φ的值
for i in range(row):
    for j in range(col):
        #        if accumulator[i,j]> voteThresh:
        if accumulator[i, j] > count[0]:
            count = [accumulator[i, j], (i, j)]  # 投票最大的参数就是幅值和相位

plt.figure(0)
plt.imshow(pic)

pic1 = np.ones((row, col)) * 255
for i in range(200):
    y1 = count[1][0] * (np.sin(i * 2 * np.pi / 200 - np.pi * count[1][1] / 180)) + 100  # 创建这么一个正弦曲线
    pic1[int(y1), i] = 0
cv2.imshow("fit",pic1)

cv2.waitKey(0)
cv2.destroyAllWindows()