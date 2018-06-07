//Author: Adam Shehadeh
//Date:   6/4/2018

open System
open System.Windows.Forms
open System.Data.SqlClient
open SQL
open FormTypes
let frm = new SQLEditorForm();
Application.Run(frm)
Console.Read() |> ignore