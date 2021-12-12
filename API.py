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


@app.route(endpoint + '/<AmiiboId>', methods=['GET'])
def GetReviewsByName(AmiiboId):
    if request.method == 'GET':

        print(AmiiboId)
        return jsonify(DataRepository.read_all_by_id(AmiiboId)), 200


@app.route(endpoint + '/<ReviewId>', methods=['PUT'])
def UpdateReview(ReviewId):

    if request.method == 'PUT':
        print("posten")
        data = request.get_json(force=True)
        DataRepository.update_review(data.get(
            'Name'), data.get('Review'), data.get('Rating'), ReviewId)

        return jsonify(readinglog="Done"), 204


# Start app
if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0')
