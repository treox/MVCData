import React from 'react';

class CreatePerson extends React.Component {
    render() {
      return(
        <div>
          <h3>Lägg till ny person:</h3>
          <form onSubmit={this.props.handleSubmit}>
            <label>Namn:</label>
            <div>
              <input 
                type="text" 
                value={this.props.name}
                onChange={event => this.props.setName(event.target.value)} 
                required />
            </div>
            <label>Telefon:</label>
            <div>
              <input type="text" 
              value={this.props.phone} 
              onChange={event => this.props.setPhone(event.target.value)}
              required />
            </div>
            <div>
              <label htmlFor="cities">Välj stad:</label>
              <br />
              <select 
              name="cities" 
              id="cities"
              value={this.props.city} 
              onChange={event => this.props.setCity(Number(event.target.value))}>
                {this.props.cityData.map((city, cityIndex) => {
                    return <option key={cityIndex} value={city.CityId}>{city.CityName}</option>
                })}
              </select>
            </div>
            <input type="submit" name="Submit" value="Lägg till" />
          </form>
        </div>
      );
    }
  }

  export default CreatePerson