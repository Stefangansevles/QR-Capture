# QR-Capture


![](https://i.imgur.com/AZBJVdE.png) 


Ever need to scan a QR Code, for example for authenication, and you don't feel like grabbing your phone? yeah. I know that feeling. That's why I made this :) 

I mainly made it for **authenication QR Code's**, but you can use it for any QR code. Whenever you scan a QR code that contains the **otpauth** protocol, it will filter out the secret key and automatically copy it to your clipboard, to make the proces even easier.

Take a look at this GIF demonstrating how QR-Capture makes the proces easier. ( **You don't need to capture the QR code accurately. You can just make a rough capture and it will work!** )

![](https://i.imgur.com/8DPIsPz.gif)

# How-To

This application is reasonably easy to use. When you start QR-Capture, your mouse turns into an selection-tool. You can now drag and select your QR code. QR-Capture will then show, with the text behind the QR code. If you want to scan another code, click on the image and select again. That's basically it!


# Usages

QR-Capture makes use of three main external functionalites combined into one application.

### QR Decoder

This is a big one. I used [Uzi Granot](https://www.codeproject.com/script/Membership/View.aspx?mid=193217)'s [QR Decoder](https://www.codeproject.com/Articles/1250071/QR-Code-Encoder-and-Decoder-NET-Framework-Standard) to scan the QR codes with QR-Capture. This is an amazing decoder and can detect QR codes when they aren't even the main focus of an image.

### Snipping code

For the selection of an area to scan an image, i mainly used [Eder A. Castro](https://www.codeproject.com/script/Membership/View.aspx?mid=3951754)'s [Snipping Tool](https://www.codeproject.com/Articles/485883/Create-your-own-Snipping-Tool) tutorial. Big thanks for that one!

### MaterialSkin

This was used for the UI to make an old Winforms application look modern :) Big thanks to [leocb](https://github.com/leocb/MaterialSkin), [donald steele](https://github.com/donaldsteele/MaterialSkin) and mainly [Ignacemaes](https://github.com/IgnaceMaes/MaterialSkin) for making and improving this project.
