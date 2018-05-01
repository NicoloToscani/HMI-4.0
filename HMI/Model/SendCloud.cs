using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;


namespace Siemens_HMI.Model
{

    class SendCloud
    {

        
        // Cloud
        static string iotHubUri = "";
        static string deviceKey = "";
        private DeviceClient deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey("", deviceKey), TransportType.Mqtt);

        
        // Send temperature to IoT Hub
        public void SendDeviceToCloudMessages(int temperature)
        {
            int messageId = 1;
            
            // JSON data to send

                
                var telemetryDataPoint = new
                {
                    messageId = messageId++,
                    deviceId = "",
                    temperature = temperature,
                    
                };
                var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
                var message = new Message(Encoding.ASCII.GetBytes(messageString));
                deviceClient.SendEventAsync(message);

            Console.WriteLine("Messagio inviato: " + temperature);





            
        }
    }

   
} 
