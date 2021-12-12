import sqlite3


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
        conn = sqlite3.connect('AmiiboReview.db', check_same_thread=False)
        conn.row_factory = DataRepository.row_to_dict
        sql = 'SELECT * FROM Review'
        result = conn.execute(sql)
        return result.fetchall()

    @staticmethod
    def read_all_by_id(Id):
        conn = sqlite3.connect('AmiiboReview.db', check_same_thread=False)
        conn.row_factory = DataRepository.row_to_dict
        sql = f"SELECT * FROM Review WHERE AmiiboId LIKE '{Id}'"
        result = conn.execute(sql)
        return result.fetchall()

    @staticmethod
    def add_review(AmiiboId, Name, Review, Rating):
        with sqlite3.connect('AmiiboReview.db') as con:
            c = con.cursor()
            c.execute("INSERT INTO Review(AmiiboId,Name , Review,Rating) VALUES(?,?,?,?)",
                      (AmiiboId, Name, Review, Rating))
            con.commit()

    @staticmethod
    def update_review(Name, Review, Rating, ReviewId):
        with sqlite3.connect('AmiiboReview.db') as con:
            c = con.cursor()
            c.execute("UPDATE Review SET Name = ?, Review = ?, Rating = ? WHERE ReviewId = ?",
                      (Name, Review, Rating, ReviewId))
            con.commit()
