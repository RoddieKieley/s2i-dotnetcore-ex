//  ------------------------------------------------------------------------------------
//  Copyright (c) 2015 Red Hat, Inc.
//  All rights reserved.
//
//  Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this
//  file except in compliance with the License. You may obtain a copy of the License at
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//  EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR
//  CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR
//  NON-INFRINGEMENT.
//
//  See the Apache Version 2.0 License for specific language governing permissions and
//  limitations under the License.
//  ------------------------------------------------------------------------------------

//
// HelloWorld_simple
//
// Command line:
//   HelloWorld_simple [brokerUrl [brokerEndpointAddress]]
//
// Default:
//   HelloWorld_simple amqp://localhost:5672 amq.topic
//
// Requires:
//   An unauthenticated broker or peer at the brokerUrl 
//   capable of receiving and delivering messages through 
//   the endpoint address.
//
using System;
using Amqp;

namespace HelloWorld_simple
{
    class HelloWorld_simple
    {
        static void Main(string[] args)
        {
            string broker  = args.Length >= 1 ? args[0] : "amqp://broker-app-amq-amqp.amq71-basic-1.svc:5672";
            string address = args.Length >= 2 ? args[1] : "amq.topic";

            Address brokerAddr = new Address(broker);
            Connection connection = new Connection(brokerAddr);
            Session session = new Session(connection);

            SenderLink sender = new SenderLink(session, "helloworld-sender", address);
            ReceiverLink receiver = new ReceiverLink(session, "helloworld-receiver", address);

            Message helloOut = new Message("Hello World!");
            sender.Send(helloOut);

            Message helloIn = receiver.Receive();
            receiver.Accept(helloIn);

            Console.WriteLine(helloIn.Body.ToString());

            receiver.Close();
            sender.Close();
            session.Close();
            connection.Close();
        }
    }
}
