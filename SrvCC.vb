Public Class SrvCC

    'CLASE PARA ASESORES -- Nombres y Apellidos van juntos

    Public Class TAsesor
        Public Property Dni As String
        Public Property Nombres As String
    End Class
    'para jalar datos de la base de datos
    'Clase personalizada que sirve como estructura para que coincida con los datos devueltos por la base de datos
    Public Class TEmpresa
        Public Property Codigo As String
        Public Property RUC As String
        Public Property RazonSocial As String
        Public Property Rubro As String
        Public Property Asesor As String
    End Class
    'CLASE PARA EMPRESAS
End Class
