# Template for starting out a new Fable React Native App using F#, .NET Core and Yarn

## Requirements
* Yarn or NPM
    * ```brew install yarn```
    * ```brew install npm```
        * (comes with Node)
* Node.js
    * ```brew install node```
* Watchman
    * ```brew install watchman```
* JDK 
    * ```brew tap AdoptOpenJDK/openjdk```
    * ```brew cask install adoptopenjdk8```
* React Native CLI
    * ```npm install -g react-native-cli```

* [.NET Core SDK](https://dotnet.microsoft.com/download)

* XCode ( for iOS )
    - install command line tools: ```xcode-select --install```

brew install node
brew install watchman
brew tap AdoptOpenJDK/openjdk
brew cask install adoptopenjdk8

## Setup
After cloning the respository cd into project root
* ```yarn```
* ```.paket/paket.exe init```
* ```.paket/paket.exe install```
* ```cd src```
* ```dotnet restore``` 


## Building JavaScript

* Building for debug: ```yarn debug```
* Building for release : ```yarn build```
* Running with auto-compiling: ```yarn watch```
    - Enables auto-updating when the F# project in ```src/``` is altered.

Output is built to ```out/```

### Running the React Native application
* iOS simulator: ```react-native run-ios```
* Android: ```react-native run-android```

Remember to build JavaScript files. If the package manager does not automatically start run ```react-native start``` before ```react-native run-(ios/android)```. 


## Error handling

### iOS
* ```No bundle URL present``` : 
    - Try cleaning build-output, kill metro bundler and rebuild. 
    - ```rm -rf ios/build/; kill $(lsof -t -i:8081); react-native run-ios```

* ```No bundle URL present``` & the packager did not start automatically: 
    - Kill running instances 
    - Start packager manually ```react-native start```
    - Re-run project after packager successfully starts ```react-native run-ios``` 

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
