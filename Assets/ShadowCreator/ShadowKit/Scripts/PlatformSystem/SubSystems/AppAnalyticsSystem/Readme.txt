
------------------------------数据统计最新版本----------------------------
数据统计SDK版本号: AppAnalyticsSystemSDK1.0.0
日期:20190417
作者：王超群

Release Notes:
初版完成

1：使用方式
第一步：
将APPID换成自己的APPID，只需要换掉APPID/APPID.cs中字符串换掉
将ChannelID换成自己的ChannelID，只需要换掉ChannelID/ChannelID.cs中字符串换掉
第二步：
直接将AppAnalyticsSystem预制体拖到Scene中
第三步：
adb shell logcat | grep "AppAnalyticsSystem"可以查看log


2：默认统计如下数据
[1]:apk一天开启次数
[2]:apk在多少台设备上使用
[3]:apk总开启次数

3：如需统计登录和注册数据
登录调用AppAnalyticsSystem.OnLogin
注册调用AppAnalyticsSystem.OnRegister