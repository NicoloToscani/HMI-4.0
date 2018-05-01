# HMI-4.0
Example of integration between OT and IT.

## Description

In this project we will show how to connect the OT (Operational Technology) factory level with the IT (Information Techlology) management level.
For example, a human machine interface (HMI) is used to read the temperature detected by a SIEMENS S7-1200 PLC and send the value to Azure IoT Hub.

## HMI
The temperature value is read by the PLC using a WPF application with MVVM pattern, using the Sharp7 library.
![](https://user-images.githubusercontent.com/12815808/39473065-49452cf2-4d4d-11e8-8c8b-02bcb5a2dae1.png)
![](https://user-images.githubusercontent.com/12815808/39473417-136fd274-4d4f-11e8-8f4c-a73068da4fb2.png)

## RECEIVE DEVICE TO CLOUD MESSAGES - CONSUMER
To receive telemetry data from the cloud, you can listen to the communication channel established with the IoT HUB service.
![](https://user-images.githubusercontent.com/12815808/39474502-9d6349d4-4d54-11e8-96f3-c17f14e5e1df.png)
