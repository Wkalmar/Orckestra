namespace Orckestra.Fsharp

open System
open System.Runtime.CompilerServices

[<Struct>]
type PermissionInfo(symbol: char, value: int) =
    member x.Symbol = symbol
    member x.Value = value


[<IsByRefLike; Struct>]
type Helpers =
    static member private Permissions =
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

    member x.ConvertBlockToOctal (block : ReadOnlySpan<char>) =
        let mutable acc = 0
        for i = 0 to Helpers.Permissions.Length - 1 do
            if block.[i] = Helpers.Permissions.[i].Symbol then
                acc <- acc + Helpers.Permissions.[i].Value
            else
                acc <- acc
        acc

