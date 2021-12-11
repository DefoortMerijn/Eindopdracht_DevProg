from flask import Flask, jsonify, request
from flask_cors import CORS
from DataRepositories.DataRepository import DataRepository
import json
import sqlite3


# Start app
app = Flask(__name__)
CORS(app)

# Custom endpoint
endpoint = '/api/v1/amiibo/review'

# ROUTES


@app.route(endpoint + '/', methods=['GET', 'POST'])
def index():
    if request.method == 'GET':
        return jsonify(DataRepository.read_all()), 200

    if request.method == 'POST':
        print("posten")
        data = request.get_json(force=True)

        print(data.get('AmiiboId'))
        DataRepository.add_review(data.get('AmiiboId'), data.get(
            'Name'), data.get('Review'), data.get('Rating'))

        return jsonify(readinglog="Done"), 201


@app.route(endpoint + '/<id>', methods=['GET'])
def GetReviewsByName(id):
    if request.method == 'GET':
        AmiiboId = str(id)
        print(AmiiboId)
        return jsonify(DataRepository.read_all_by_id(AmiiboId)), 200


# Start app
if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0')
