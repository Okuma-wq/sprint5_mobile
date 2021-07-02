import React, { Component } from 'react';
import { Image, TextInput, StyleSheet, View, Text, TouchableOpacity, ImageBackground } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      senha: '',
      erro : '',
      idLoading : false
    }
  }

  validarLogin = () => {
    const email = this.state.email;
    if (email == null || email.length === 0) {
        this.setState({erro : 'O e-mail é obrigatório!'});
        return false;
    }

    const senha = this.state.senha;
    if (senha == null || senha.length === 0) {
        this.setState({erro : 'A senha é obrigatória!'});
        return false;
    }

    return true;
}

realizarLogin = async () => {
  if (this.validarLogin()) {
      
      this.setState({isLoading : true})

      const response = await api.post('/login', {
          email : this.state.email,
          senha : this.state.senha
      })

      .then(response => {
          switch (response.status) {
              case 200:
                  const token = response.data.token;

                  this.setState({erro : ''})

                  AsyncStorage.setItem('token', token);

                  

                  //console.warn('teste')
                  
                  this.props.navigation.navigate('Main');
                  
                  break;

              case 404:
                  response.json().then(result => {
                      result => {
                          this.setState({erro : result})
                      }
                  })
                  break;
          
              default:
                  response.json().then(result => {
                      result => {
                          this.setState({erro : result})
                      }
                  })
                  break;
          }
      })

      .catch(erro => {
          this.setState({erro : 'E-mail ou senha incorretos!'})
      })

      this.setState({isLoading : false})

  }
}

  render() {
    return (
      <ImageBackground
        source={require('../../assets/img/imagem.png')}
        style={StyleSheet.absoluteFillObject}
      >
        <View style={styles.overlay} />
        <View style={styles.main}>

          <Image
            source={require('../../assets/img/logo_spmedgroup.png')}
            style={styles.mainImgLogin}
          />

          <TextInput
            style={styles.inputLogin}
            placeholder='Email'
            placeholderTextColor='#FFF'
            keyboardType='email-address'
            onChangeText={email => this.setState({ email })}
          />

          <TextInput
            style={styles.inputLogin}
            placeholder='Senha'
            placeholderTextColor='#FFF'
            //secureTextEntry= {true}
            onChangeText={senha => this.setState({ senha })}
          />

          <TouchableOpacity
            style={styles.btnLogin}
            onPress={this.realizarLogin}
          >
            <Text style={styles.btnLoginText}>Login</Text>
          </TouchableOpacity>

          {this.state.erro === '' ? <Text></Text>:
          <Text style={{color: 'white', textAlign: 'center', backgroundColor: 'rgba(41, 91, 172, 0.60)', fontWeight: 'bold', marginTop: 6, position:'relative', paddingLeft: 24, paddingRight: 24}}>{this.state.erro}</Text>
          }


        </View>
      </ImageBackground>
    )
  }
}

const styles = StyleSheet.create({
  overlay: {
    ...StyleSheet.absoluteFillObject,
    backgroundColor: 'rgba(41, 91, 172, 0.60)',
  },

  main: {
    height: '100%',
    width: '100%',
    alignItems: 'center',
    justifyContent: 'center',
  },

  mainImgLogin: {
    height: 110,
    width: 103,
    margin: 40,
    marginTop: 0
  },

  inputLogin: {
    width: 240,
    marginBottom: 40,
    fontSize: 18,
    color: '#fff',
    borderBottomColor: '#fff',
    borderBottomWidth: 2
  },

  btnLogin: {
    alignItems: 'center',
    justifyContent: 'center',
    height: 38,
    width: 240,
    backgroundColor: 'rgb(45, 45, 255)',
    borderRadius: 30,
    shadowOffset: { height: 1, width: 1 }
  },

  btnLoginText: {
    fontSize: 15,
    textTransform: 'uppercase'
    
  }

});
