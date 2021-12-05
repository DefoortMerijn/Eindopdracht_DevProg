from os import error
from mysql import connector  # pip install mysql-connector-python

import sqlite3


class Database:
    @staticmethod
    def get_all(sqlQuery):
        result = None
        conn = sqlite3.connect('OwnedAmiibo.db', check_same_thread=False)
        c = conn.cursor()
        try:
            c.execute(sqlQuery)
            result = c.fetchall()
            conn.commit()
            conn.close()
            if result is None:
                print(ValueError(f"Resultaten zijn onbestaand.[DB Error]"))
                conn.close()
        except Exception as error:
            print(error)
            result = None
        finally:
            return result

    @staticmethod
    def execute_sql(sqlQuery, params=None):

        result = None
        db = sqlite3.connect('OwnedAmiibo.db', check_same_thread=False)
        c = db.cursor()
        try:
            print("ik ben in database")
            print(sqlQuery)
            print(params)
            c.execute(sqlQuery, params)
            print(c.execute(sqlQuery, params))
            db.commit()
            result = c.lastrowid
            if result is None:
                print(ValueError(f"Resultaten zijn onbestaand.[DB Error]"))
                db.close()
                if result != 0:  # is een insert, deze stuur het lastrowid terug.
                    result = result
            else:  # is een update of een delete
                if c.rowcount == -1:  # Er is een fout in de SQL
                    raise Exception("Fout in SQL")
                elif (
                    c.rowcount == 0
                ):  # Er is niks gewijzigd, where voldoet niet of geen wijziging in de data
                    result = 0
                elif result == "undefined":  # Hoeveel rijen werden gewijzigd
                    raise Exception("SQL error")
                else:
                    result = c.rowcount
        except connector.Error as error:
            print(error)
            result = None
        finally:
            db.close()
            return result
