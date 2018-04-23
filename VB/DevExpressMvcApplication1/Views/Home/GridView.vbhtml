@ModelType System.Collections.IEnumerable

@Code		 
	Dim grid = Html.DevExpress().GridView(Sub(settings)
				settings.Name = "grid"
				settings.KeyFieldName = "ProductID"
				settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "InlineEditingPartial"}
				settings.Settings.ShowPreview = true
				settings.Columns.Add("ProductID")
				settings.Columns.Add("ProductName")
				
				settings.Columns.Add("Discontinued", MVCxGridViewColumnType.CheckBox)
				
				settings.Styles.PreviewRow.CssClass = "customPreviewRow"
				settings.SetPreviewRowTemplateContent(Sub(container)
					Html.ViewContext.Writer.Write("<div><b>Units in Stock: {0} </b></div>", DataBinder.Eval(container.DataItem, "UnitsInStock"))
				End Sub)
				settings.ClientSideEvents.EndCallback = "OnEndCallback"
				settings.ClientSideEvents.Init = "OnInit"

			End Sub)
End Code
@grid.Bind(Model).GetHtml()