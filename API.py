from flask import Flask, jsonify, request
from flask_cors import CORS

# Start app
app = Flask(__name__)
CORS(app)

# Custom endpoint
endpoint = '/api/v1'


# ROUTES

@app.route('/')
def index():
    return 'use /api/v1', 303


# Start app
if __name__ == '__main__':
    app.run(debug=True)
