import React from 'react';

class CreateLanguage extends React.Component {
    render(){
        return(
            <div>
                <h3>Lägg till språk:</h3>
                <form onSubmit={this.props.handleLanguageSubmit}>
                    <div>
                        <label htmlFor="people">Lägg till person:</label>
                        <br />
                        <select 
                        name="people" 
                        id="people"
                        value={this.props.person} 
                        onChange={event => this.props.setPerson(Number(event.target.value))}>
                          {this.props.peopleData.map((person, personIndex) => {
                              return <option key={personIndex} value={person.PersonDTOId}>{person.PersonDTOName}</option>
                          })}
                        </select>
                    </div>
                    <div>
                        <label htmlFor="languages">Lägg till språk:</label>
                        <br />
                        <select 
                        name="languages" 
                        id="languages"
                        value={this.props.language} 
                        onChange={event => this.props.setLanguage(Number(event.target.value))}>
                          {this.props.languageData.map((language, languageIndex) => {
                              return <option key={languageIndex} value={language.LanguageId}>{language.LanguageName}</option>
                          })}
                        </select>
                    </div>
                    <input type="submit" name="SubmitLang" value="Lägg till språk" />
                </form>
            </div>
        );

    }
}

export default CreateLanguage