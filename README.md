# MQCoordinator

# Getting Started:
* Make sure you can downoad nuget packages
* Ensure your RabbitMQ is running under "localhost". You can enable the management plugin as necessary (http://www.rabbitmq.com/management.html)
* Build all projects in the solution
  * Open up the two plugin \bin\ folders.
  * There should be a sub-folder in each of them with the name of the plugin. This contains all the libraries/dependencies
  * Open up the MQCoordinator Forms app \bin\Plugins folder
  * Drag the two plugin folders found above into the \bin\Plugins folder
* Run the MQCoordinator forms app
* Click "LoadAllPlugins". This will load any plugins in the folder and all of their referenced assemblies
* Type in a city/state if you'd like in the second text box
* Click "Enqueue", this creates the message on the "VehicleQueue" message queue
* Check to ensure the message has appeared on the queue
* Click Register Queue Handler in the tool.
  * It should take the message off the queue and send to each of the loaded plugins for processing.
  * If it worked, in your \bin\ folder in the MQCoordinator forms app, you should have two text files
    * BlackBook.txt - Created by the blackbook plugin that serialized your message using protobuf-net library
    * Kbb.txt - Created by the Kbb plugin that called out to the Google API via the Google API Nuget library that printed out HTML directions from my home to your destination

To change the behavior, just change the plugin implementations (BlackBookPlugin.cs/KbbPlugin.cs), build, copy over the new folders into the bin\plugins\ folder, and re-run the tool

TODO:
* Add each plugin into it's own isolated app-domain
* Load and unload plugins based on a watcher in the plugins folder
