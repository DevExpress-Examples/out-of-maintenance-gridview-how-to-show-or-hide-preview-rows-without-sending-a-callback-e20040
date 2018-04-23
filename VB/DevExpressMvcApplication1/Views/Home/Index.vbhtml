@Code
	ViewBag.Title = "How to Show and Hide Previev Rows without Sending a Callback to a Server"
End Code
<script language="javascript" type="text/javascript">
	var showRows = false;
	function OnShowClick(s, e) {
		showRows = true;
		ShowHideRows();
	}
	function OnHideClick(s, e) {
		showRows = false;
		ShowHideRows();
	}
	function ShowHideRows() {
		
		if (showRows)
			$(".customPreviewRow").show();
		else
			$(".customPreviewRow").hide();
	}
	function OnEndCallback(s, e) {
		ShowHideRows();
	}
	function OnInit(s, e) {
		ShowHideRows();
	}	
</script>
@ModelType System.Collections.IEnumerable
@Html.Partial("GridView", Model)

@Html.DevExpress().Button(Sub(s)
	s.Name = "showButton"
	s.Text = "Show Preview"
	s.UseSubmitBehavior = false
	s.ClientSideEvents.Click = "OnShowClick"
End Sub).GetHtml()

@Html.DevExpress().Button(Sub(s)
	s.Name = "hideButton"
	s.Text = "Hide Preview"
	s.UseSubmitBehavior = false
	s.ClientSideEvents.Click = "OnHideClick"
End Sub).GetHtml()