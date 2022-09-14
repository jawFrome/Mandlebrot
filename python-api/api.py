import flask
from flask import request, jsonify, send_file
from flask_api import status
from Mandlebrot import IsInTheSet, getImageOfRange

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

@app.route('/imageofrange', methods=['GET'])
def imageOfRange():
    if 'minreal' in request.args and 'minimag' in request.args and 'maxreal' in request.args and 'maximag' in request.args:
        minreal = float(request.args['minreal'])
        minimag = float(request.args['minimag'])
        maxreal = float(request.args['maxreal'])
        maximag = float(request.args['maximag'])
    else:
        return "Error: No min/max real or imag provided. Please specify."

    if (minreal > maxreal or minimag > maximag):            
            return "Min and max values incorrect", status.HTTP_400_BAD_REQUEST            
  
    image = getImageOfRange([minreal, maximag], [maxreal, minimag])

    return send_file(image, mimetype='image/bmp')

app.run()