# 西一爱服 小花仙登录器 / CEFHuaClient
## 恢复更新，此版本体积较大，但提供了自定义分辨率的截图功能
[![GitHub release (latest by date)](https://img.shields.io/github/v/release/No5972/CEFHuaClient?label=%E7%82%B9%E6%AD%A4%E4%B8%8B%E8%BD%BD%E6%9C%80%E6%96%B0%E7%89%88%E6%9C%AC%EF%BC%88%E9%87%8C%E9%9D%A2%E7%9A%84%E8%93%9D%E5%A5%8F%E4%BA%91%E9%93%BE%E6%8E%A5%EF%BC%89)](https://github.com/No5972/CEFHuaClient/releases/latest)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FNo5972%2FCEFHuaClient.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FNo5972%2FCEFHuaClient?ref=badge_shield)

## 注意：
* 不兼容屏幕字体缩放125%或以上。兼容最多屏幕字体缩放124%或不缩放。
* 不兼容WinXP和其他32位系统。本工具目前仅对64位Win7、Win8、Win10、Win11兼容。
* 支持最低分辨率1366x768。
* 自定义截图功能要求运行内存不少于8G。
* 当前仅支持淘米账号密码登录和微信扫码登录，暂不支持QQ登录。
* 必须要C++ 2015运行库才能运行。若打开报错提示“未能加载文件或程序集“CefSharp.Core.dll”或它的某一个依赖项。找不到指定的模块”，请留意系统设置的“应用和功能”是否安装了Microsoft Visual C++ 2015 Redistributable (x64)，如果没有请安装这个C++ 2015运行库，记得装64位的。
* 如果打开时提示“该版本过旧，不支持运行，请升级后使用”，请将电脑上所有的“Shockwave Flash”目录删除（注意删除前确保各个Shockwave Flash目录下没有重要文件），然后从hosts文件屏蔽这些域名：geo2.adobe.com, fpdownload2.macromedia.com, fpdownload.macromedia.com, macromedia.com。（关于hosts文件屏蔽域名具体步骤请自行搜索） 这样可以继续使用该版本的Flash Player。

## 功能说明：
* **截图：** 将当前显示的画面截图。即使是设置了超出屏幕分辨率窗口大小，或者将窗口拖动到部分显示于屏幕以外，也能完整截图。
* **下拉框：** 切换窗口大小，除自定义选项以外其他选中后立刻生效。自定义项选中后可以手动输入需要使用的窗口大小，但是前提电脑要能带的动足够大的分辨率，否则有可能会卡死。
* **重置Flash路径：** 正常情况能加载游戏则不要点击此按钮。若启动时指定了错误的Flash组件文件导致一直显示“Right click to run Adobe Flash Player”则可以点击此按钮重新选择正确的Flash组件文件。
* **自定义截图：** 可以指定截图尺寸、缩放倍率、视野移动来进行截图。默认给出了一套参数，此参数用于截图玩家面板的社区形象（16：9竖屏尺寸8K高清），对于截取社区形象可以直接确定使用。
  - 几个预设值：
    - 截玩家面板：截图宽：4320，截图高7680，视野偏移X：-4500，视野偏移Y：-2000，倍率：5.0
    - 截图鉴形象：截图宽：7680，截图高7680，视野偏移X：4500，视野偏移Y：-2500，倍率：6.0
    - 截坐骑预览：截图宽：4320，截图高7680，视野偏移X：-4500，视野偏移Y：-3000，倍率：7.5
* **模拟衣服替换：** 用于给角色替换游戏中任意的衣服，但是只有自己看的到，别人看到的还是替换之前的衣服。此按钮为下拉菜单，有两个选项：模拟衣服替换、查找部件ID。
  - **模拟衣服替换：** 点击添加按钮，然后输入要替换的部件ID（部位暂不用指定），输入要使用的部件ID，然后点击保存选中。可以再次点击添加按钮来添加其他部位或者给其他玩家替换的衣服。全部录入完毕点击确认，然后重新打开玩家的面板即可看到替换的效果。
  - **查找部件ID：** 先打开本窗口，然后打开玩家面板的搭配信息，或者图鉴的查看部件，就可以在本窗口查看加载出来的各部件的ID，依次选中可以在右侧预览窗格确认对应的衣服部件。监测按钮可以切换暂停或开启检测。清空按钮可以清空实时读取的列表。
* **调试：** 预留了一个手动打开F12开发者工具的按钮。此按钮可以打开F12开发者工具。
* **自定义背景：** 可以将玩家面板的社区形象的背景改成纯色背景，以便抠图。目前暂时只支持黑色、白色、红色、绿色、蓝色背景。只有穿戴背景秀的玩家才能生效。
* **刷新：** 游戏开启时间过长导致游戏卡顿时可以点击此按钮重新加载游戏。除点击本按钮之外也可以使用 ```Alt + F5``` 快捷键来刷新。
* **配置鼠标连点：** 用来设置鼠标连点的间隔时间，单位是毫秒。鼠标连点功能可以通过 ```Alt + F6``` 切换开启和关闭。仅在窗口所在的屏幕范围内有效（弹出页面若鼠标在主窗口的范围内也有效）。仅支持鼠标左键连点。

![image](https://github.com/No5972/CEFHuaClient/blob/main/screenshots/mainwindow.png)
![image](https://github.com/No5972/CEFHuaClient/blob/main/screenshots/customizecapture1.png)
![image](https://github.com/No5972/CEFHuaClient/blob/main/screenshots/simulatereplace.png)
![image](https://github.com/No5972/CEFHuaClient/blob/main/screenshots/monitor.png)

# 改口小花仙登录器体积较小，但不支持自定义分辨率截图功能、模拟衣服替换功能
[https://github.com/No5972/GeckoHuaClient](https://github.com/No5972/GeckoHuaClient)


## License
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FNo5972%2FCEFHuaClient.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2FNo5972%2FCEFHuaClient?ref=badge_large)
