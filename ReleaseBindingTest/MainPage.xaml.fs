namespace ReleaseBindingTest

open Xamarin.Forms
open Xamarin.Forms.Xaml
open FSharp.Data
open System.Diagnostics

type MainPage() =
    inherit ContentPage()
    let _ = base.LoadFromXaml(typeof<MainPage>)

    let clickMe = base.FindByName<Button>("ClickMe")


    let apiLookup () = 
        async {
            let! r = Http.AsyncRequest("http://codingwithsam.com")
            let count = 
                match r.Body with 
                | Text t -> t.Length 
                | Binary _ -> 0
            sprintf "%d" count |> Debug.WriteLine 
        }

    do 
        clickMe.Clicked.Add (fun _ -> 
            apiLookup () |> Async.RunSynchronously)

    
