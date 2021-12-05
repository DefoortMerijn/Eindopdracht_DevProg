from .Database import Database


class DataRepository:
    @staticmethod
    def json_or_formdata(request):
        if request.content_type == 'application/json':
            gegevens = request.get_json()
        else:
            gegevens = request.form.to_dict()
        return gegevens

    @staticmethod
    def read_all():
        sql = 'SELECT * FROM amiibo'
        return Database.get_all(sql)

    @staticmethod
    def create_log(Id, name):
        sql = "INSERT INTO amiibo(id,name) VALUES(%s,%s)"
        params = [Id, name]
        print(params)
        print(Database.execute_sql(sql, params))
        return Database.execute_sql(sql, params)
