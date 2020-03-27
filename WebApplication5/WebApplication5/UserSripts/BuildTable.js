$(document).ready(function ()
{
    $.ajax(
        {
            url: '/Todos/BuildToDotable',
            success: function (result)
            {
                $('#tableDiv').html(result);
            }
        })
})