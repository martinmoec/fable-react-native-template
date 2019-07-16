module App

open Elmish
open Elmish.React
open Elmish.ReactNative
open Elmish.HMR
open Fable.ReactNative

type Model = {
    Counter : int
    Input : string
}


type Message =
    | Increment 
    | Decrement 
    | UpdateInput of string
    | RequestError of exn


let init () =

    let cmds = Cmd.batch [
        Cmd.none
    ]

    { Counter = 0; Input = "" }, cmds


// UPDATE

let update (msg : Message ) ( model : Model ) : Model * Cmd<Message> =
    match msg  with
    | Increment ->

        { model with Counter = model.Counter + 1 }, Cmd.none 
    
    | Decrement  ->
        { model with Counter = model.Counter - 1 }, Cmd.none
    
    | UpdateInput inpt ->
        { model with Input = inpt }, Cmd.none
    
    | RequestError e ->
        model, Cmd.none

// rendering views with ReactNative
module R = Fable.ReactNative.Helpers
module P = Fable.ReactNative.Props


let view model ( dispatch : Dispatch<Message> ) =

    // main view element
    R.view [
        P.ViewProperties.Style [ 
            P.ShadowColor "#333333"
            P.FlexStyle.Flex 1.0 
            P.ShadowOpacity 0.8
            P.ShadowRadius 3.
            P.BackgroundColor "#131313" ]
    ] [
        
        R.text [
            
            P.TextProperties.Style [
                P.Color "#336699"
                P.FlexStyle.Top ( pct 40.)
                P.FontSize 30.
                P.TextAlign P.TextAlignment.Center
                
                
            ]
        ] "Hello World" 

        R.textInput [
            P.TextInput.AutoCorrect false
            P.TextInput.AutoFocus true
            P.TextInput.TextInputProperties.Style [
                P.Color "#ffffff"
                P.BorderBottomWidth 2.
                P.BorderBottomColor "#336699"
                P.TextAlign P.TextAlignment.Center
                P.FontSize 30.
                P.FlexStyle.Top ( pct 50.0 )
            ]
            P.TextInput.Placeholder "Enter text here"
            P.TextInput.PlaceholderTextColor "#aaaaaa"
            P.TextInput.OnChangeText ( UpdateInput >> dispatch ) 
        ]

        R.text [
            P.TextProperties.Style [
                
                P.Color "#f6f6f6"
                P.FlexStyle.Top ( pct 60.)
                P.FontSize 15.
                P.TextAlign P.TextAlignment.Center
                
            ]
        ] model.Input
    ]

// initialize app
Program.mkProgram init update view
|> Program.withConsoleTrace
|> Program.withReactNative "ReactNativeApp"
|> Program.run
