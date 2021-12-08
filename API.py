from flask import Flask, jsonify, request
from flask_cors import CORS
from DataRepositories.DataRepository import DataRepository
import json
import sqlite3

# Start app
app = Flask(__name__)
CORS(app)

# Custom endpoint
endpoint = '/api/v1/amiibo'

# ROUTES


def json_or_formdata(request):
    if request.content_type == 'application/json':
        gegevens = request.get_json()
    else:
        gegevens = request.form.to_dict()
        return gegevens


@app.route(endpoint + '/', methods=['GET', 'POST'])
def index():
    if request.method == 'GET':
        return json.dumps(DataRepository.read_all()), 200

    if request.method == 'POST':
        print("posten")
        data = DataRepository.json_or_formdata(request)
        print(data.get('id'))
        DataRepository.create_log(data.get('id'), data.get('name'))

        return jsonify(readinglog="Done"), 201


# Start app
if __name__ == '__main__':
    app.run(debug=True)
