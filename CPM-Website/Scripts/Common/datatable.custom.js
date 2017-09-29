$(document).on('init.dt', function (e, settings) {
    var api = new $.fn.dataTable.Api(settings);

    console.log('New DataTable created:', api.table().node());
});