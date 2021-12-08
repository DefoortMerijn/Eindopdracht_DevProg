import sqlite3
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
    def row_to_dict(cursor: sqlite3.Cursor, row: sqlite3.Row) -> dict:
        data = {}
        for idx, col in enumerate(cursor.description):
            data[col[0]] = row[idx]
        return data

    @staticmethod
    def read_all():
        conn = sqlite3.connect('OwnedAmiibo.db', check_same_thread=False)
        conn.row_factory = DataRepository.row_to_dict
        sql = 'SELECT * FROM amiibo'
        result = conn.execute(sql)
        return result.fetchall()

    @staticmethod
    def create_log(Id, Name):
        with sqlite3.connect('OwnedAmiibo.db') as con:
            c = con.cursor()
            c.execute("INSERT INTO amiibo(id,name) VALUES(?,?)", (Id, Name))
            con.commit()
