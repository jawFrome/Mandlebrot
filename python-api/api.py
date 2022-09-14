import flask
from flask import request, jsonify
from Mandlebrot import IsInTheSet

app = flask.Flask(__name__)
app.config["DEBUG"] = True


@app.route('/isinset', methods=['GET'])
def isInSet():
    if 'real' in request.args and 'imag' in request.args:
        real = float(request.args['real'])
        imag = float(request.args['imag'])
    else:
        return "Error: No real or imag provided. Please specify."

    return jsonify(IsInTheSet(real, imag))

def imageOfRange():
    return "Todo"

app.run()