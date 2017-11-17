$.extend( $.fn.dataTable.defaults, {
    searching: false,
    ordering: true,
    processing: true,
    serverSide: true,
    language: {
        url: '/vendors/datatables.net/i18n/vi_VN.js'
    },
    dom: `  <"row"
                    <"col-md-4"l>
                    <"col-md-4"i>
                    <"col-md-4"p>>
            <"row"frt>
            <"row"
                    <"col-md-4"l>
                    <"col-md-4"i>
                    <"col-md-4"p>>
`
} );