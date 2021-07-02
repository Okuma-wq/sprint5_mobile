import React, { Component } from 'react';
import { StyleSheet, Text, View, ImageBackground, Image, TouchableOpacity } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import jwtDecode from 'jwt-decode';


export default class Perfil extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: ''
    }
  }

  buscarDadosStorage = async () =>{
    try {
      const token = await AsyncStorage.getItem('token');
      if(token !== null){
        this.setState({ email : jwtDecode(token).email})
      }

      console.warn(this.state.email)
    } catch (error) {
    }
  }

  logout = async () => {
    try {
      await AsyncStorage.removeItem('token');
      this.props.navigation.navigate('Login');
    } catch (error) {
      
    }
  }
  

  componentDidMount(){
    this.buscarDadosStorage();
  }

  render() {
    return (
      <ImageBackground
        source={require('../../assets/img/imagem.png')}
        style={StyleSheet.absoluteFillObject}
      >
        <View style={styles.overlay} />
        <View style={styles.main}>
          <View style={styles.mainHeader}>
            <View style={styles.mainHeaderRow}>
              <Image
                source={require('../../assets/img/profile.png')}
                style={styles.mainHeaderImg}
              />
              <Text style={styles.mainHeaderText}>{'Perfil'.toUpperCase()}</Text>
            </View>
            <View style={styles.mainHeaderLine} />
          </View>

          <View style={styles.mainBody}>
            <View style={styles.mainBodyImg}/>

            <Text style={styles.mainBodyText}>{this.state.email}</Text>
          </View>

          <TouchableOpacity
            style={styles.btnLogout}
            onPress={this.logout}
          >
            <Text style={styles.btnLogoutText}>Sair</Text>
          </TouchableOpacity>
        </View>
      </ImageBackground>
    )
  }
}

const styles = StyleSheet.create({
  overlay: {
    ...StyleSheet.absoluteFillObject,
    backgroundColor: 'rgba(41, 91, 172, 0.80)',
  },

  main: {
    flex: 1,
    // backgroundColor: '#F1F1F1',
    alignItems: 'center',
    // justifyContent: 'center',
  },

  //Cabeçalho
  mainHeader: {
    flex: 1,
    marginTop: 30,
    justifyContent: 'center',
    alignItems: 'center',
    // backgroundColor: 'red'
  },

  mainHeaderRow: {
    flexDirection: 'row'
  },

  mainHeaderImg: {
    width: 22,
    height: 22,
    tintColor: '#fff',
    marginTop: -2
  },

  mainHeaderText: {
    fontSize: 16,
    letterSpacing: 5,
    color: '#fff'
  },

  mainHeaderLine: {
    width: 170,
    paddingTop: 10,
    borderBottomColor: '#fff',
    borderBottomWidth: 1
  },

  // conteúdo do body
  mainBody: {
    flex: 4,
    // alignItems: 'center',
    // justifyContent: 'space-between'
  },
  // informações do usuário
  mainBodyInfo: {
    alignItems: 'center'
  },
  mainBodyImg: {
    backgroundColor: '#ccc',
    width: 100,
    height: 100,
    borderRadius: 50,
    marginBottom: 50
  },
  mainBodyText: {
    color: '#fff',
    fontSize: 16,
    marginBottom: 20
  },
  // botão de logout
  btnLogout: {
    alignItems: "center",
    justifyContent: "center",
    height: 38,
    width: 240,
    backgroundColor: 'rgb(45, 45, 255)',
    borderRadius: 30,
    shadowOffset: { height: 1, width: 1 },
    borderColor: "#ccc",
    marginBottom: 100
  },
  // texto do botão
  btnLogoutText: {
    fontSize: 16,
    color: "#fff"
  }

});