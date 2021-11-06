from flask.helpers import url_for
from pyTrendsExtensions import GetTrendingOverTime
from flask import Flask, redirect
# from flask_restful import Api, Resource, reqparse, abort, fields, marshal_with
# from flask_sqlalchemy import SQLAlchemy

app = Flask(__name__)
# api = Api(app)

@app.route("/")
def hello():
    return redirect("http://127.0.0.1:5000/test", code=302)

@app.route("/<keyword>")
def GetTrandingDataForKeyword(keyword):
    return GetTrendingOverTime(keyword)