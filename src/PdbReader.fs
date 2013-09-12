#light
namespace FOO
open Mono.Cecil
open System
open System.IO


module PdbReader = 
    
    let toString bytes = Text.Encoding.UTF8.GetString bytes

    let readPdbInfo dllPath = 
        let m = ModuleDefinition.ReadModule(dllPath:string)
        let header, bytes = m.GetDebugHeader()
        let rsds = toString bytes.[0..3]
        if "RSDS" <> rsds then
            failwithf "unable to read pdb info from %s" dllPath
        let guid = Guid bytes.[4..19]
        //let n = BitConverter.ToUInt32(bytes, 20)
        let fileName = (toString bytes.[24..]).TrimEnd [|(char)0uy|] |> Path.GetFileName
        fileName, guid
