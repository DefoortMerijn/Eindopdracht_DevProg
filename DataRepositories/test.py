import sqlite3

conn = sqlite3.connect('OwnedAmiibo.db', check_same_thread=False)
c = conn.cursor()
c.execute('CREATE TABLE amiibo (id text, name text)')
conn.commit()
conn.close()
