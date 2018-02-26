# Event-based-socket

a simple C# library on .NET 4.5

using and Extend .net client socket on System.Net.Sockets

A few simple functions and several intelligent events

## Methods

for connecting to TCP Server use `Connect` method
return boolean result for success in run
```csharp
var socket = new ClientEventSocket();
bool result = socket.Connect("127.0.0.1", 23);
```


for disconnecting from TCP Server use `Disonnect` method
return boolean result for success in run
```csharp
var socket = new ClientEventSocket();
bool result = socket.Disonnect();
```

for sending data to TCP Server use `Send` or `SendEof` method
return boolean result for success in run
```csharp
var socket = new ClientEventSocket();
bool result = socket.Send("Simple");
bool resultEof = socket.SendEof("Simple", ';');
```

## Events

Events occurred on every actions like OnConnected, OnDisconnected, OnSended, OnReceived, OnError

```csharp

        /// <summary>
        /// Event occurred on Connected to TCP Server.
        /// Raise After [Connect] Method to show results.
        /// </summary>
        public EventHandler<string> OnConnected;

        /// <summary>
        /// Event occurred On Disconnected from TCP Server.
        /// Raise after [Disonnect] method to show results.
        /// Raise after disconneting from TCP Server for any reason.
        /// </summary>
        public EventHandler<string> OnDisconnected;

        /// <summary>
        /// Event occurred on Send Data To TCP Server.
        /// Raise after [Send] or [SendEof] methods to show results.
        /// </summary>
        public EventHandler<string> OnSended;

        /// <summary>
        /// Event occurred on Received Data from TCP Server.
        /// Raise after received new data and show [Data] by string parameter.
        /// </summary>
        public EventHandler<string> OnReceived;

        /// <summary>
        /// Event occurred on Errors.
        /// Raise after each error anywhere.
        /// </summary>
        public EventHandler<string> OnError;
```

