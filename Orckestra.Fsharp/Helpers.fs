namespace Orckestra.Fsharp

open System

[<Struct>]
type PermissionInfo(symbol: char, value: int) =
    member x.Symbol = symbol
    member x.Value = value


type Helpers =
    val private Permissions : PermissionInfo[]
    new () = {
        Permissions = 
        [|PermissionInfo('r', 4);
        PermissionInfo('w', 2);
        PermissionInfo('x', 1);
        PermissionInfo('r', 4);
        PermissionInfo('w', 2);
        PermissionInfo('x', 1);
        PermissionInfo('r', 4);
        PermissionInfo('w', 2);
        PermissionInfo('x', 1);
        PermissionInfo('r', 4);
        PermissionInfo('w', 2);
        PermissionInfo('x', 1); |]
    }    

    member x.ConvertBlockToOctal (block : ReadOnlySpan<char>) =
        let mutable acc = 0
        for i = 0 to x.Permissions.Length - 1 do
            if block.[i] = x.Permissions.[i].Symbol then
                acc <- acc + x.Permissions.[i].Value
            else
                acc <- acc
        acc

