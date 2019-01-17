# Template for starting out a new Fable React Native App using F#, .NET Core and Yarn

## Requirements
* Node.js
* Watchman
* React Native CLI
* .NET Core SDK >= 2.0.0
* XCode ( for iOS )

## Setup
After cloning the respository cd into project root
* ```yarn```
* ```.paket/paket.exe init```
* ```.paket/paket.exe install```
* ```cd src```
* ```dotnet restore``` 

## Running
### Start fable watch-server (enables auto-updating, optional)
From project root 
* ```cd src```
* ```dotnet fable yarn-watch```

Enables auto-updating when the F# project in ```src/``` is altered. Output is built to ```out/```.

### React-native 
In project root
* iOS simulator: ```react-native run-ios```
* Android: ```react-native run-android```

## Error handling

### iOS
* ```No bundle URL present``` : 
    - Try cleaning build-output, kill metro bundler and rebuild. 
    - ```rm -rf ios/build/; kill $(lsof -t -i:8081); react-native run-ios```
* ```Entry, ":CFBundleIdentifier", Does Not Exist``` and similar
    - open ```ios/ReactNativeApp.xcodeproj``` in XCode
    - File -> Project Settings... -> Advanced
        - Set build location to Custom
        - Replace ```Build/..``` with ```build/Build/...``` for the Products and Intermediates entries
        - E.g 
            - Products: ```build/Build/Products```
            - Intermediates: ```build/Build/Intermediates.noindex```

### Android

* Licenses not accepted
    - run ```<Android folder>/sdk/tools/bin/sdkmanager --licenses``` and accept all
