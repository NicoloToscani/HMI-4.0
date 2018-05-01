# HMI-4.0
Example of integration between OT and IT.

## Description

In this project we will show how to connect the OT (Operational Technology) factory level with the IT (Information Techlology) management level.
For example, a human machine interface (HMI) is used to read the temperature detected by a SIEMENS S7-1200 PLC and send the value to Azure IoT Hub.

## HMI
The temperature value is read by the PLC using a WPF application with MVVM pattern, using the Sharp7 library.
![](https://user-images.githubusercontent.com/12815808/39473065-49452cf2-4d4d-11e8-8c8b-02bcb5a2dae1.png)
![](https://user-images.githubusercontent.com/12815808/39477971-3c2697a4-4d61-11e8-87a1-fc73ffba44e1.png)

## Consumer - Receive device to cloud messages
To receive telemetry data from the cloud, you can listen to the communication channel established with the IoT HUB service.
![](https://user-images.githubusercontent.com/12815808/39478035-71f52bd4-4d61-11e8-9f93-c9a3f0d942f1.png)
