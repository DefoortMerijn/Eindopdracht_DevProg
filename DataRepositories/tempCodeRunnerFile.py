import sqlite3

conn = sqlite3.connect('AmiiboReview.db', check_same_thread=False)
c = conn.cursor()
# c.execute("""CREATE TABLE "Review" (
# 	"ReviewId"	INTEGER UNIQUE,
# 	"AmiiboId"	TEXT NOT NULL,
# 	"Name"	TEXT,
# 	"Review"	TEXT,
# 	"Rating"	REAL NOT NULL,
# 	PRIMARY KEY("ReviewId" AUTOINCREMENT)
# )""")
c.execute("""Delete From Review WHERE AmiiboId LIKE "1111a" """)
conn.commit()
conn.close()
