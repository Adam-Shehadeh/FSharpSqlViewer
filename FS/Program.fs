open System
open System.Windows.Forms
open System.Data.SqlClient
open SQLDataLayer
open FormExtension
open FormTypes
let frm = new SQLEditorForm();
Application.Run(frm)

Console.Read() |> ignore